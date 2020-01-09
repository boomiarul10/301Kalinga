import {Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import {IBrand} from '../Brand';
import {Component, Input} from '@angular/core';

@Injectable()

export class BrandService{
//  getbrandNames : string[] {
//    return new string[] = ["String1","String2"];
//  }
   private _brandlistURL = "http://localhost:51400/Api/BrandConfig";
   private brandlst : IBrand[];

   constructor(private _http : HttpClient){ }

   getValues() : Observable<IBrand[]> {
       return this._http.get<IBrand[]>(this._brandlistURL);
       //return this.brandlst;
   }
   
   getValuesbyID(Id:number) : Observable<IBrand> {
    return this._http.get<IBrand>(this._brandlistURL+'/'+Id);
    //return this.brandlst;
}

DeleteValuesbyID(Id:number) : Observable<IBrand> {
    return this._http.delete<IBrand>(this._brandlistURL+'/'+Id);
}

};