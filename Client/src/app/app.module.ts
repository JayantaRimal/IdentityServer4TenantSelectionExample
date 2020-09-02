import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AuthModule, OidcConfigService } from 'angular-auth-oidc-client';
import { AppComponent } from './app.component';
import { CustomInterceptor } from './custom-interceptor';
import { AuthorizationGuard } from './authorization-guard.service';
import { FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { environment } from '../environments/environment';


export function configureAuth(oidcConfigService: OidcConfigService) {
    return () =>
       
        oidcConfigService.withConfig({
            stsServer: environment.sts_server,
            redirectUrl: window.location.origin,
            postLogoutRedirectUri: window.location.origin,
            clientId: 'js',
            scope: 'openid profile web_api database_name',
            responseType: 'code',
            silentRenew: true,
            silentRenewUrl: `${window.location.origin}/silent-renew.html`,
            autoCleanStateAfterAuthentication: true

        });
}


@NgModule({
    declarations: [AppComponent],
    imports: [

        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: '', component: AppComponent },
            { path: 'home', component: AppComponent },
            { path: 'forbidden', component: AppComponent },
            { path: 'unauthorized', component: AppComponent },
        ]),
        AuthModule.forRoot(),

       
    ],
    providers: [
      OidcConfigService,
      {
          provide: APP_INITIALIZER,
          useFactory: configureAuth,
          deps: [OidcConfigService],
          multi: true,
      },
      {
        provide: HTTP_INTERCEPTORS,
        useClass: CustomInterceptor,
        multi: true
      },
      AuthorizationGuard
  ],
    bootstrap: [AppComponent],
})
export class AppModule {
  
}
