declare namespace TimesheetImport {
    interface ITimesheetSite {
        siteId: string;
        siteName: string;

    }

    interface ITimesheetImportResult {
        Notifications: INotification[]
    }

    interface INotification{
        lineNumber: string;
        Message: string;
    }

    interface FileUploadRequest
    {
        siteId: string;
        File: File;
    }

}
