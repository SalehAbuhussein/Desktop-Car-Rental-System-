using FontAwesome.Sharp;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Cars_Rental.Global_Classes
{
    public static class Utility
    {
        public static bool SaveUsernameAndPassword(string username, string password)
        {
            string keyPath = @"HKEY_CURRENT_USER\Software\CarsRentalSystem";

            try
            {
                Registry.SetValue(keyPath, "Username", username, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", password, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error has occured! => {ex.Message}");
            }

            return false;
        }

        public static bool GetStoredUsernameAndPassword(ref string username, ref string password)
        {
            string keyPath = @"HKEY_CURRENT_USER\Software\CarsRentalSystem";

            try
            {
                username = Registry.GetValue(keyPath, "Username", "") as string;
                password = Registry.GetValue(keyPath, "Password", "") as string;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong => {ex.Message}");
            }

            return false;
        }

        public static string GetAppFolder()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.FullName;
        }

        public static bool CreateDirectory(string folderName)
        {
            string directory = Path.Combine(GetAppFolder(), folderName);

            if (Directory.Exists(directory))
            {
                return true;
            }

            try
            {
                DirectoryInfo di = Directory.CreateDirectory(directory);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The caller does not have the required permission to create `{ex.Message}`");
            }

            return false;
        }

        public static string GetCarImagesDirectory()
        {
            return Path.Combine(GetAppFolder(), "car-images");
        }

        public static bool StoreCarImage(string imgPath, ref string newImgPath)
        {
            if (CreateDirectory("car-images"))
            {
                string newImgName = GetGuid() + Path.GetExtension(imgPath);
                string destinationPath = Path.Combine(GetCarImagesDirectory(), newImgName);

                CopyFile(imgPath, destinationPath);

                newImgPath = destinationPath;
                return true;
            } else
            {
                Console.WriteLine("Creation failed");
            }

            return false;
        }

        public static string GetGuid()
        {
            Guid guid = Guid.NewGuid();

            return guid.ToString();
        }

        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static Image GetFontAwesomeImage(IconChar icon, Color color, int size = 20)
        {
            return icon.ToBitmap(color, size);
        }

        public static string OpenImageFile(System.Windows.Forms.FileDialog dialog)
        {
            dialog.FileName = string.Empty;
            dialog.InitialDirectory = @"C:\";

            // Filter by file extension (optional)
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            dialog.Title = "Select an Image File";

            // This line FORCES the dialog to open
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            } else
            {
                return string.Empty;
            }
        }

        public static void CopyFile(string source, string destination)
        {
            using (FileStream sourceStream = new FileStream(
                source,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read
            ))
            {
                using (FileStream destinationStream = new FileStream(
                    destination,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None
                ))
                {
                    sourceStream.CopyTo(destinationStream);
                }
            }
        }

        public static Image LoadImage(string imgPath)
        {
            using (FileStream fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (Image tempImage = Image.FromStream(fs))
                {
                    return new Bitmap(tempImage);
                }
            }
        }
    }
}
