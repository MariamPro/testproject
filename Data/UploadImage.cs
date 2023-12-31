namespace project.Data
{
    public class UploadImage
    {
        private readonly IWebHostEnvironment _hostenvorment;
        public UploadImage(IWebHostEnvironment hostenvorment )
        {
            _hostenvorment = hostenvorment;
            Console.WriteLine("c");
        }
            
        public async  Task<string> MoveImageToServer(IFormFile image , string folder)
        {
        folder += Guid.NewGuid().ToString() + "_" + image.FileName;
                string serverFolderDocument = Path.Combine(_hostenvorment.WebRootPath, folder);
                await image.CopyToAsync(new FileStream(serverFolderDocument, FileMode.Create));
            Console.WriteLine(serverFolderDocument);

                return folder;
        }
    }
}
