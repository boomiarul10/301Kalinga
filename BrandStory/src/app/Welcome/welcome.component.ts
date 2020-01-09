import {Component} from '@angular/core';
import { ICarouselConfig, AnimationConfig, CarouselModule } from 'angular4-carousel';

@Component({
templateUrl: './welcome.component.html',
styleUrls:['./welcome.component.css']
})

export class WelcomeComponent{

    public imageSources: string[] = [
        './assets/images/PG_Ariel.png',
    './assets/images/PG_joy.png',
    './assets/images/PG_febreze.jpg',
    './assets/images/PG_Downy.png'
     ];
     
     public config: ICarouselConfig = {
       verifyBeforeLoad: true,
       log: false,
       animation: true,
       animationType: AnimationConfig.SLIDE,
       autoplay: true,
       autoplayDelay: 3000,
       stopAutoplayMinWidth: 768
     };
}