using TimesheetImportAPI.Models;

namespace TimesheetImportAPI.Mappers
{
    public static class FormFilemapper
    {
        public static FileUploadRequest? Map(this IFormFile formFile)
        {
            byte[]? fileBytes = null;

            if (formFile != null && formFile.Length != 0)
            {
                using (var file = new MemoryStream())
                {
                    formFile.CopyTo(file);
                    fileBytes = file.ToArray();
                }


                return new FileUploadRequest(formFile.FileName, formFile.ContentType, fileBytes);
            }
            return null;
        }
    }
}
