import { Component, Input } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { PersonModel } from '../_models/person.model';
import { NationalityEnum } from '../_enumurations/nationality.enum';

@Component({
    selector: 'app-enter-exit', 
    animations: [
      trigger('flyInOut', [
        state('in', style({ 
         })),

        transition('void => *', [
          style({ 
            top: 0
          }),
          animate(3000)
        ]),
        //  transition('* => void', [
        //    style({
        //      bottom:0, 
        //     }),
        //    animate(3000)
        //  ])
      ])
    ],
    templateUrl: 'enter-leave.component.html',
    styleUrls: ['enter-leave.component.scss']
  })
  export class OpenCloseComponent {
  
    @Input() person = PersonModel;
    
    constructor() {
    }

    get nationalityEnum(): typeof NationalityEnum{
      return NationalityEnum;
    }
  
  }