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
        errorMessage: string;
    }

}
