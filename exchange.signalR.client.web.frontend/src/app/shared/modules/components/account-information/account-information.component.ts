import { Component,Input,ViewChild,AfterViewInit } from "@angular/core";
import { NgRedux, select } from "@angular-redux/store";
import { AppState } from "@store/app.state";
import { Observable } from "rxjs";
import { NotificationContainer } from "@interfaces/notification-container.interface";
import { MatAccordion } from '@angular/material/expansion';
import { MainService } from "@services/main.service";
import { ExchangeUIContainer } from "@interfaces/exchange-ui-container.interface";
import { AccountInfo } from "@interfaces/account-info.interface";

@Component({
    selector: "account-information-component",
    templateUrl: "./account-information.component.html",
})
export class AccountInformationComponent implements AfterViewInit {
    @Input() applicationName: string;
    @ViewChild(MatAccordion) accordion: MatAccordion;

    @select("notificationContainer") notificationContainer$: Observable<NotificationContainer>;
    notificationContainer: NotificationContainer;
    @select("exchangeUIContainer") exchangeUIContainer$: Observable<ExchangeUIContainer>;
    exchangeUIContainer: ExchangeUIContainer;
    accountInfo: AccountInfo[];

    constructor(private ngRedux: NgRedux<AppState>, private mainService: MainService) {
        this.accountInfo = new Array();
        this.notificationContainer$.subscribe((x: NotificationContainer) => {
            this.notificationContainer = x;
        });
        this.exchangeUIContainer$.subscribe((x: ExchangeUIContainer) => {
            this.exchangeUIContainer = x;
            this.accountInfo = x.accountInfo.filter((accountInfo:AccountInfo) => {
                return accountInfo.applicationName == this.applicationName;
            });
        });
    }
    ngAfterViewInit() {
        this.mainService.hub_requestedAccountInfo();
    }
}
