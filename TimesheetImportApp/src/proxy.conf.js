const PROXY_CONFIG = [
  {
    context: [
      "/api/timesheetimport",
      "/api/weatherforecast"
    ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
