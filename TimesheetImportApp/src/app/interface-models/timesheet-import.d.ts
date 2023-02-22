declare namespace TimesheetImport {
  interface ITimesheetSite {
    siteId: string;
    siteName: string;
  }

  interface ITimesheetImportResult {
    timesheetDetails: ITimesheetDetail[];
    notifications: INotification[];
    errors: INotification[];
    warnings: INotification[];
    hasErrors: boolean;
    hasWarnings: boolean;
  }

  interface ITimesheetImportConfirmationResult {
    success: boolean;
    notifications: INotification[];
  }

  interface INotification {
    lineNumber: string;
    message: string;
    severity: number;
  }

  interface FileUploadRequest {
    siteId: string;
    File: File;
  }

  interface ITimesheetDetail {
    timeCreatedBy: number;
    timeCreatedDate: Date;
    timeUpdatedBy: number;
    timeUpdatedDate: Date;
    timeTimeStamp: Date;
    timeSecterr?: number;
    timeStatus: string;
    timeCompanyId?: number;
    timeEmployeeid?: number;
    timeStartdate: Date;
    timeEnddate: Date;
    timeNormalhrs?: number;
    timeNightshifthrs?: number;
    timeSundayhrs?: number;
    timeSiteid?: number;
    timeBreaktimehrs?: number;
    timePosition?: number;
    timeShift: string;
    timeStarttime: string;
    timeEndtime: string;
    timeWorkedhrs?: number;
    timeSource: string;
    timeBatchNo?: number;
    timeWeek?: number;
    timeTimesheetrunid?: number;
    timeNewweek?: number;
    timePhhrs?: number;
  }

}
