using TimesheetImportAPI.Models;

namespace TimesheetImportAPI.Mappers
{
    public static class FormFilemapper
    {
        public static TimesheetImport.TimesheetModels.FileUploadRequest? Map(this FileUploadRequest fileUploadRequest)
        {
            MemoryStream? uploadFile = null;

            if (fileUploadRequest != null && fileUploadRequest.FormCollection != null && fileUploadRequest.FormCollection?.Files.Count != 0)
            {
                using (var file = new MemoryStream())
                {
                    fileUploadRequest.FormCollection?.Files[0].CopyTo(file);
                    uploadFile = file;
                    uploadFile.Position = 0;
                }

                return new TimesheetImport.TimesheetModels.FileUploadRequest()
                {
                    File = uploadFile,
                    SiteId = fileUploadRequest.SiteId,
                };
            }
            return null;
        }
    }
}
