import { Component,OnInit,Input,ViewChild,AfterViewInit } from "@angular/core";
import { NgRedux, select } from "@angular-redux/store";
import { AppState } from "@store/app.state";
import { Observable } from "rxjs";
import { NotificationContainer } from "@interfaces/notification-container.interface";
import { MainService } from "@services/main.service";
import { ExchangeUIContainer } from "@interfaces/exchange-ui-container.interface";
import { FormControl } from '@angular/forms';
import { ProductInfo } from "@interfaces/product-info.interface";
import { AccountInfo } from "@interfaces/account-info.interface";

@Component({
    selector: "product-information-component",
    templateUrl: "./product-information.component.html",
})
export class ProductInformationComponent implements AfterViewInit, OnInit {
    @Input() applicationName: string;
    @select("notificationContainer") notificationContainer$: Observable<NotificationContainer>;
    notificationContainer: NotificationContainer;
    @select("exchangeUIContainer") exchangeUIContainer$: Observable<ExchangeUIContainer>;
    exchangeUIContainer: ExchangeUIContainer;
    formControl: FormControl;
    assetList: string[];
    currentAssetList: string[];

    constructor(private ngRedux: NgRedux<AppState>, private mainService: MainService) {
        this.formControl = new FormControl();
        this.assetList = new Array();
        this.currentAssetList = new Array();
    }

    ngOnInit() {
        this.notificationContainer$.subscribe((x: NotificationContainer) => {
            this.notificationContainer = x;
        });
        this.exchangeUIContainer$.subscribe((x: ExchangeUIContainer) => {
            this.exchangeUIContainer = x;
            this.assetList = new Array();
            this.currentAssetList = new Array();

            //requires ES6 support, Babel or TypeScript
            x.productInfo.forEach((productInfo: ProductInfo)=>{
                if(productInfo.applicationName == this.applicationName){
                    this.assetList.push(productInfo.asset);

                    x.accountInfo.forEach((accountInfo: AccountInfo) => {
                        if(accountInfo.applicationName == this.applicationName){

                            if(productInfo.asset.indexOf(accountInfo.asset) !== -1)
                            {
                                let index: number = this.currentAssetList.findIndex((asset: string) => {
                                    return asset === productInfo.asset;
                                });
                                if(index === -1){
                                    this.currentAssetList.push(productInfo.asset);
                                }
                            } 
                        }
                    });
                }
            });
        });
    }

    ngAfterViewInit() {
        this.mainService.hub_requestedProducts();
    }

    subscribe(){
        this.mainService.hub_requestedSubscription(this.applicationName,this.formControl.value)
    }
}
