declare namespace TimesheetImport {
  interface ITimesheetSite {
    siteId: string;
    siteName: string;
  }

  interface ITimesheetImportResult {
    success: boolean;
    notifications: INotification[];
  }

  interface INotification {
    lineNumber: string;
    message: string;
  }

  interface FileUploadRequest {
    siteId: string;
    File: File;
  }

}
