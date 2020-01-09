import {Component} from '@angular/core';
import {CarouselModule} from 'angular4-carousel';
import { ICarouselConfig, AnimationConfig } from 'angular4-carousel';

@Component({
    templateUrl:'./home.component.html',
    styleUrls:['./home.component.css']
})

export class HomeComponent{
    
    public imageSources: string[] = [
        './assets/images/Carousel (1).jpg',
        './assets/images/Carousel (2).jpg',
        './assets/images/Carousel (3).jpg',
        './assets/images/Carousel (4).jpg'
     ];
     
     public config: ICarouselConfig = {
       verifyBeforeLoad: true,
       log: false,
       animation: true,
       animationType: AnimationConfig.SLIDE,
       autoplay: true,
       autoplayDelay: 2000,
       stopAutoplayMinWidth: 768
     };
}