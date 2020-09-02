import { Injectable } from '@angular/core';
import { Router, Route, CanActivate, CanLoad, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, of, Subject } from 'rxjs';
import { map,concatAll, flatMap, switchMap } from 'rxjs/operators';

import { OidcSecurityService } from 'angular-auth-oidc-client';

@Injectable()
export class AuthorizationGuard implements CanActivate, CanLoad {
    constructor(private router: Router, private oidcSecurityService: OidcSecurityService) {}

    private allowedRoles:string[];

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {

        this.allowedRoles = route.data["roles"];
        return this.checkUser();
    }

    canLoad(state: Route): Observable<boolean> {

        
        return this.checkUser();
    }

    private checkRole():Observable<boolean>
    {

        return this.oidcSecurityService.userData$.pipe(map((userInfo: any) => {

            var role = userInfo.role;
            if(this.allowedRoles.indexOf(role) !== -1) {
                return true;
            }
            else{
                return false;
            }
        }))
    }

    private checkUser(): Observable<boolean> {
        
        var subject = new Subject<Observable<boolean>>();
          this.oidcSecurityService.checkAuth().pipe(
            map((isAuthorized: boolean) => {
                if (!isAuthorized) {
                    this.router.navigate(['/unauthorized']);
                    return false;
                }
                else{
                
                  return true;
                }
            })
        ).subscribe((roleBool)=>
        {
            if(roleBool==true)
            {
                subject.next(this.checkRole());
            }
            else
            {
                 subject.next(of(false));
            }


        });

        return subject.asObservable().pipe(concatAll());
       
    }
}
