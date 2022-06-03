import { OnInit, Component } from '@angular/core';
import { SharedService } from 'src/app/_services/shared.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-home-page',
    templateUrl: 'home-page.component.html'
})
export class HomePageComponent implements OnInit{

    score: number;
    gameDone = false;

    constructor(private sharedService: SharedService,
        private router: Router) {
    }

    ngOnInit(){
        this.score = this.sharedService.getScore();
        this.gameDone = this.sharedService.isGameDone();
    }

    startGame(){
        this.sharedService.setScore(0);
        this.sharedService.setGameDone(false);
        this.router.navigateByUrl('/game-page');
    }
}