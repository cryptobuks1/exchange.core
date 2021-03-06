import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { NgReduxModule } from "@angular-redux/store";
import { FormsModule,ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { NotificationComponent } from "./components/notification/notification.component";
import { PriceCardComponent } from "./components/price-card/price-card.component";
import { AccountInformationComponent } from "./components/account-information/account-information.component";
import { ProductInformationComponent } from "./components/product-information/product-information.component";

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from "@angular/material/core";
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatMenuModule } from '@angular/material/menu';
import { MatCardModule } from '@angular/material/card';
import { MatSidenavModule } from '@angular/material/sidenav';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatSelectModule } from '@angular/material/select';
import { AccountInformationTableComponent } from "./components/account-information-table/account-information-table.component";
import { MatTableModule } from "@angular/material/table";


@NgModule({
    imports: [
        BrowserModule,
        HttpClientModule,
        CommonModule,
        FormsModule,
        NgReduxModule,
        MatExpansionModule,
        BrowserAnimationsModule,
        MatNativeDateModule ,
        ReactiveFormsModule,
        MatToolbarModule, MatButtonModule, MatIconModule,MatFormFieldModule,MatTableModule,
        MatInputModule,MatDatepickerModule,MatDividerModule,MatListModule,MatGridListModule,
        MatMenuModule,MatCardModule,FlexLayoutModule, MatSidenavModule,MatSelectModule
    ],
    exports: [
        FormsModule,
        CommonModule,
        BrowserAnimationsModule,
        NotificationComponent,
        PriceCardComponent,
        AccountInformationComponent,
        ProductInformationComponent,
        AccountInformationTableComponent,
        MatNativeDateModule ,
        MatToolbarModule, MatButtonModule, MatIconModule, MatExpansionModule,MatTableModule ,
        MatFormFieldModule,MatInputModule,MatDatepickerModule,MatDividerModule,MatListModule,MatGridListModule,
        MatMenuModule,MatCardModule,FlexLayoutModule,MatSidenavModule,MatSelectModule,ReactiveFormsModule
    ],
    providers: [MatDatepickerModule],
    declarations: [NotificationComponent, PriceCardComponent, AccountInformationComponent, ProductInformationComponent, AccountInformationTableComponent],
})
export class SharedModule {}
