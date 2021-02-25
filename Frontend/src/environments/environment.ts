// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  // wsURL : 'https://api.job-tomori.com:60045/PROD/Dashboard_PSI.asmx?WSDL',
  apiURL : 'http://localhost:44348/api/',
   //baseWSAddress : 'https://api.job-tomori.com:60067/DEV/',
   App_Name : 'ATrans',
   modulUser : 'UserLogins/',
   modulFormPop : 'WS_ATrans_FormPopulator.asmx?WSDL',
   modulRequest : 'WS_ATrans_Request.asmx?WSDL',
  //wsURL : 'http://localhost:54399/Dashboard_PSI.asmx?WSDL',
  appName : 'Library System'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
