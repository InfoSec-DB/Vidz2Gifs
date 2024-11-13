using System;
using System.Diagnostics;
using System.Drawing; // For Point, Color, and Image processing
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xabe.FFmpeg;

namespace VideoToGifConverter
{
    public partial class Form1 : Form
    {
        private readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "results.txt");

        // Variables for dragging the form
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Form1()
        {
            InitializeComponent();
            InitializeLogger();

            // Set default selection
            rdoProcessVideo.Checked = true;
            UpdateUIForSelection();
        }

        // Initialize logging by clearing any old log and starting fresh
        private void InitializeLogger()
        {
            try
            {
                if (File.Exists(logFilePath))
                {
                    File.Delete(logFilePath);
                }
                Log("Application started. Logger initialized.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing logger: {ex.Message}");
            }
        }

        // Method to log messages to the results.txt file
        private void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
                Debug.WriteLine(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logging failed: {ex.Message}");
            }
        }

        // Event handler for radio buttons
        private void RdoProcessVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProcessVideo.Checked)
            {
                UpdateUIForSelection();
            }
        }

        private void RdoProcessImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProcessImage.Checked)
            {
                UpdateUIForSelection();
            }
        }

        // Method to update UI based on selection
        private void UpdateUIForSelection()
        {
            bool isVideoSelected = rdoProcessVideo.Checked;

            // Show/hide video controls
            lblVideoPath.Visible = isVideoSelected;
            txtVideoPath.Visible = isVideoSelected;
            btnBrowseVideo.Visible = isVideoSelected;
            lblGifPath.Visible = isVideoSelected;
            txtGifPath.Visible = isVideoSelected;
            btnSaveGif.Visible = isVideoSelected;

            // Show/hide image controls
            lblImagePath.Visible = !isVideoSelected;
            txtImagePath.Visible = !isVideoSelected;
            btnBrowseImage.Visible = !isVideoSelected;
            lblImageOutputPath.Visible = !isVideoSelected;
            txtImageOutputPath.Visible = !isVideoSelected;
            btnSaveImage.Visible = !isVideoSelected;

            // Update the Convert button text
            btnConvert.Text = isVideoSelected ? "Convert to GIF" : "Add Watermark to Image";
        }

        // Event handler for browsing video files
        private void BtnBrowseVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv;*.hevc;*.m4v;*.wmv;*.flv;*.webm|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtVideoPath.Text = openFileDialog.FileName;
                Log($"Video file selected: {txtVideoPath.Text}");
            }
            else
            {
                Log("No video file selected.");
            }
        }

        // Event handler for browsing image files
        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = openFileDialog.FileName;
                Log($"Image file selected: {txtImagePath.Text}");
            }
            else
            {
                Log("No image file selected.");
            }
        }

        // Event handler for selecting the save location for the GIF
        private void BtnSaveGif_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "GIF Files|*.gif",
                DefaultExt = "gif"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtGifPath.Text = saveFileDialog.FileName;
                Log($"GIF save path selected: {txtGifPath.Text}");
            }
            else
            {
                Log("No GIF save path selected.");
            }
        }

        // Event handler for selecting the save location for the watermarked image
        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                DefaultExt = "png"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtImageOutputPath.Text = saveFileDialog.FileName;
                Log($"Image save path selected: {txtImageOutputPath.Text}");
            }
            else
            {
                Log("No image save path selected.");
            }
        }

        private async void BtnConvert_Click(object sender, EventArgs e)
        {
            bool isVideoSelected = rdoProcessVideo.Checked;

            // Common parameters
            bool isWatermarkEnabled = chkEnableWatermark.Checked;
            string watermarkText = txtWatermarkText.Text;

            if (isWatermarkEnabled && string.IsNullOrWhiteSpace(watermarkText))
            {
                MessageBox.Show("Please enter watermark text.");
                Log("Error: Watermark text is empty.");
                return;
            }

            try
            {
                progressBar.Value = 0;
                progressBar.Style = ProgressBarStyle.Marquee; // Start progress indication

                if (isVideoSelected)
                {
                    // Video processing
                    string videoPath = txtVideoPath.Text;
                    string gifPath = txtGifPath.Text;

                    Log("Video conversion process started.");
                    Log($"Video Path: {videoPath}");
                    Log($"GIF Path: {gifPath}");

                    // Validate paths
                    if (string.IsNullOrWhiteSpace(videoPath) || string.IsNullOrWhiteSpace(gifPath))
                    {
                        MessageBox.Show("Please select both a video file and a destination for the GIF.");
                        Log("Error: Either video path or gif path is missing.");
                        return;
                    }

                    await ConvertVideoToGif(videoPath, gifPath, isWatermarkEnabled, watermarkText);
                    Log("Video conversion completed successfully.");
                }
                else
                {
                    // Image processing
                    string imagePath = txtImagePath.Text;
                    string outputImagePath = txtImageOutputPath.Text;

                    Log("Image watermarking process started.");
                    Log($"Image Path: {imagePath}");
                    Log($"Output Image Path: {outputImagePath}");

                    // Validate paths
                    if (string.IsNullOrWhiteSpace(imagePath) || string.IsNullOrWhiteSpace(outputImagePath))
                    {
                        MessageBox.Show("Please select both an image file and a destination for the output image.");
                        Log("Error: Either image path or output image path is missing.");
                        return;
                    }

                    await AddWatermarkToImage(imagePath, outputImagePath, watermarkText);
                    Log("Image watermarking completed successfully.");
                }

                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 100;
                MessageBox.Show("Operation complete!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                Log($"Error during operation: {ex}");
            }
        }

        // Method to convert video to GIF
        private async Task ConvertVideoToGif(string videoPath, string gifPath, bool isWatermarkEnabled, string watermarkText)
        {
            try
            {
                // Set the FFmpeg executables directory
                string ffmpegDirectory = AppDomain.CurrentDomain.BaseDirectory;
                Log($"FFmpeg directory set: {ffmpegDirectory}");
                FFmpeg.SetExecutablesPath(ffmpegDirectory);

                // Get media info to retrieve frame rate
                IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(videoPath);
                var videoStream = mediaInfo.VideoStreams.FirstOrDefault();
                double frameRate = videoStream?.Framerate ?? 24;
                Log($"Original video frame rate: {frameRate}");

                // Cap the frame rate if it's too high
                if (frameRate > 30)
                {
                    frameRate = 30;
                    Log("Frame rate capped at 30 fps");
                }

                // Temporary path for the palette
                string palettePath = Path.Combine(Path.GetDirectoryName(gifPath), "palette.png");
                Log($"Palette path set: {palettePath}");

                // Delete existing palette file if it exists
                if (File.Exists(palettePath))
                {
                    File.Delete(palettePath);
                    Log("Existing palette file deleted.");
                }

                // Filters
                string fpsFilter = $"fps={frameRate}";
                string scaleFilter = "scale=420:-1:flags=lanczos";
                string paletteGenFilter = $"{fpsFilter},{scaleFilter},palettegen=max_colors=128";

                // Generate the palette
                Log("Starting palette generation...");
                var paletteGen = FFmpeg.Conversions.New()
                    .AddParameter($"-i \"{videoPath}\" -vf \"{paletteGenFilter}\" -y -frames:v 1", ParameterPosition.PreInput)
                    .SetOutput(palettePath)
                    .SetOverwriteOutput(true);

                // Capture FFmpeg output during palette generation
                paletteGen.OnDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrWhiteSpace(args.Data))
                    {
                        Log($"FFmpeg: {args.Data}");
                    }
                };

                Log($"Palette generation command: {paletteGen.Build()}");
                await paletteGen.Start();
                Log("Palette generation completed.");

                // Build the filter complex string
                string filterComplex;
                if (isWatermarkEnabled)
                {
                    Log("Applying watermark text to GIF.");

                    // Watermark text parameters
                    string fontfile = @"C:\Windows\Fonts\arial.ttf"; // Update this path as needed

                    // Escape colons and backslashes in fontfile path
                    string fontfileEscaped = fontfile.Replace(@"\", "/").Replace(":", @"\:");

                    string fontSize = "20";        // Adjust as needed
                    string fontColor = "white";     // Text color
                    string alpha = "0.7";          // Opacity (0.0 - fully transparent, 1.0 - fully opaque)

                    // **Positioning (centered and a bit to the right)**
                    string xPosition = "(w-text_w)/2 + 50";
                    string yPosition = "(h-text_h)/2";

                    // Escape any special characters in the text
                    string escapedText = watermarkText.Replace("'", @"\'")
                                                      .Replace(":", @"\:")
                                                      .Replace(@"\", @"\\")
                                                      .Replace(",", @"\,")
                                                      .Replace("[", @"\[")
                                                      .Replace("]", @"\]");

                    // Build the drawtext filter
                    string drawTextFilter = $"drawtext=fontfile='{fontfileEscaped}':text='{escapedText}':" +
                                            $"fontcolor={fontColor}@{alpha}:fontsize={fontSize}:" +
                                            $"x={xPosition}:y={yPosition}:box=0";

                    // Complete filter complex
                    filterComplex = $"[0:v]{fpsFilter},{scaleFilter},{drawTextFilter}[x];[x][1:v]paletteuse=dither=bayer:bayer_scale=3";
                }
                else
                {
                    // Without watermark
                    filterComplex = $"[0:v]{fpsFilter},{scaleFilter}[x];[x][1:v]paletteuse=dither=bayer:bayer_scale=3";
                }

                // Build the conversion command
                var gifConversion = FFmpeg.Conversions.New()
                    .AddParameter($"-i \"{videoPath}\" -i \"{palettePath}\"", ParameterPosition.PreInput)
                    .AddParameter("-y") // Overwrite output files without asking
                    .AddParameter($"-filter_complex \"{filterComplex}\"")
                    .AddParameter("-loop 0")
                    .AddParameter("-map_metadata -1") // Remove metadata
                    .SetOutput(gifPath)
                    .SetOverwriteOutput(true);

                // Capture FFmpeg output during GIF conversion
                gifConversion.OnDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrWhiteSpace(args.Data))
                    {
                        Log($"FFmpeg: {args.Data}");
                    }
                };

                Log($"GIF conversion command: {gifConversion.Build()}");
                await gifConversion.Start();
                Log("GIF conversion completed.");

                // Delete the temporary palette file
                if (File.Exists(palettePath))
                {
                    File.Delete(palettePath);
                    Log("Temporary palette file deleted.");
                }
            }
            catch (Exception ex)
            {
                Log($"Error in ConvertVideoToGif method: {ex}");
                throw; // Re-throw the exception to be caught by the calling method
            }
        }

        // Method to add watermark to image
        private async Task AddWatermarkToImage(string imagePath, string outputImagePath, string watermarkText)
        {
            try
            {
                // Set the FFmpeg executables directory
                string ffmpegDirectory = AppDomain.CurrentDomain.BaseDirectory;
                Log($"FFmpeg directory set: {ffmpegDirectory}");
                FFmpeg.SetExecutablesPath(ffmpegDirectory);

                // Build the drawtext filter
                string fontfile = @"C:\Windows\Fonts\arial.ttf"; // Update this path as needed

                // Escape colons and backslashes in fontfile path
                string fontfileEscaped = fontfile.Replace(@"\", "/").Replace(":", @"\:");

                string fontSize = "24";        // Adjust as needed
                string fontColor = "white";     // Text color
                string alpha = "1.0";          // Opacity (0.0 - fully transparent, 1.0 - fully opaque)

                // **Positioning (centered and a bit to the right)**
                string xPosition = "(w-text_w)/2 + 50";
                string yPosition = "(h-text_h)/2";

                // Escape any special characters in the text
                string escapedText = watermarkText.Replace("'", @"\'")
                                                  .Replace(":", @"\:")
                                                  .Replace(@"\", @"\\")
                                                  .Replace(",", @"\,")
                                                  .Replace("[", @"\[")
                                                  .Replace("]", @"\]");

                string drawTextFilter = $"drawtext=fontfile='{fontfileEscaped}':text='{escapedText}':" +
                                        $"fontcolor={fontColor}@{alpha}:fontsize={fontSize}:" +
                                        $"x={xPosition}:y={yPosition}:box=0";

                // Build the conversion command
                var imageConversion = FFmpeg.Conversions.New()
                    .AddParameter($"-i \"{imagePath}\"", ParameterPosition.PreInput)
                    .AddParameter("-y") // Overwrite output files without asking
                    .AddParameter($"-vf \"{drawTextFilter}\"")
                    .AddParameter("-map_metadata -1") // Remove metadata
                    .SetOutput(outputImagePath)
                    .SetOverwriteOutput(true);

                // Capture FFmpeg output during image conversion
                imageConversion.OnDataReceived += (sender, args) =>
                {
                    if (!string.IsNullOrWhiteSpace(args.Data))
                    {
                        Log($"FFmpeg: {args.Data}");
                    }
                };

                Log($"Image conversion command: {imageConversion.Build()}");
                await imageConversion.Start();
                Log("Image watermarking completed.");
            }
            catch (Exception ex)
            {
                Log($"Error in AddWatermarkToImage method: {ex}");
                throw; // Re-throw the exception to be caught by the calling method
            }
        }

        // Custom close button click event handler
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Mouse events for dragging the form
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }

        // Optional: Change close button appearance on hover
        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.ForeColor = Color.Red;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.ForeColor = Color.White;
        }
    }
}
