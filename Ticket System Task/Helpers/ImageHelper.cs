namespace Ticket_System_Task.Helpers
{
    public class ImageHelper
    {
        public static string ConvertImageToBase64(string imagePath)
        {
            try
            {
                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                {
                    throw new ArgumentException("Image path is invalid or file does not exist.");
                }

                byte[] imageBytes = File.ReadAllBytes(imagePath);
                string base64String = Convert.ToBase64String(imageBytes);
                return $"data:image/jpeg;base64,{base64String}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image to Base64: {ex.Message}");
                return string.Empty; 
            }
        }
    }
}
