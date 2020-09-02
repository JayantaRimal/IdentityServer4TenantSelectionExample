import { Component, OnDestroy, OnInit } from '@angular/core';
import { OidcClientNotification, OidcSecurityService, PublicConfiguration } from 'angular-auth-oidc-client';

@Component({
    selector: 'app-root',
    templateUrl: 'app.component.html',
})
export class AppComponent implements OnInit, OnDestroy {
    isAuthenticated: boolean;
    isConfigurationLoaded: boolean;
    userData: any;

    constructor(public oidcSecurityService: OidcSecurityService) {}

    ngOnInit() {

        this.oidcSecurityService.checkAuth().subscribe(auth => {
            this.isAuthenticated = auth;
        });

        this.oidcSecurityService.userData$.subscribe(userData => {
            this.userData = userData;
        });
    }

    ngOnDestroy(): void {}

    login() {
        this.oidcSecurityService.authorize();
    }

    logout() {
        this.oidcSecurityService.logoff();
    }

}
