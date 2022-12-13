const PROXY_CONFIG = [
  {
    context: [
      "/TimesheetImportAPI/api/timesheetimport",
      "/api/weatherforecast"
    ],
    target: "http://localhost/TimesheetImportAPI/",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
