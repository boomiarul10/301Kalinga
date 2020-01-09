import {Component} from '@angular/core';
import {IBrand} from '../Brand';
import { BrandService } from '../Service/Brand.Service';
import {ActivatedRoute} from '@angular/router';

@Component({
    templateUrl:'./brandedit.component.html',
    styleUrls:['./brandedit.component.css']
})

export class BrandEditComponent{

    BrandValue : IBrand;
    //ErrorMsg : String;
    ID : number;
    //sub : Any;

    constructor(private _brandService : BrandService, private route: ActivatedRoute){}

    

    ngOnInit() :void{
        //this.sub = 
        this.route.params.subscribe(params => { this.ID = +params['id']}); // (+) converts string 'id' to a number
     
            // In a real app: dispatch action to load the details here.
         //});

        this._brandService.getValuesbyID(this.ID).subscribe(brandnames => this.BrandValue = brandnames);
    }

}