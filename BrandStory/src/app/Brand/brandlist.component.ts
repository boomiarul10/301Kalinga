import {Component} from '@angular/core';
import { BrandService } from '../Service/Brand.Service';
import {IBrand} from '../Brand';

@Component({
    templateUrl:'./brandlist.component.html',
    styleUrls:['./brandlist.component.css']
})

export class BrandListComponent{

    BrandValue : IBrand[];
    BrandVal : IBrand;
    ErrorMsg : String;

    constructor(private _brandService : BrandService){}

    OnDeleteClick(Id: number) : void {
      this._brandService.DeleteValuesbyID(Id);
      //.subscribe(brandnames => this.BrandVal = brandnames);
    }

    OnDeleteClk(id: number) : void {
        alert ('Confirm Deletion of Id: ' + id);
      }

    ngOnInit() :void{
        this._brandService.getValues().subscribe(brandnames => this.BrandValue = brandnames, error => this.ErrorMsg = <any>Error);
    }
}