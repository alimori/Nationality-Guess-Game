import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class SharedService {

    score = 0;
    gameDone = false;

    constructor() {
    }

    setScore(score: number) {
        this.score = score;
    }

    increasScore() {
        this.score += 20;
    }

    DecreaseScore() {
        this.score -= 5;
    }

    getScore() {
        return this.score;
    }

    setGameDone(gameDone: boolean) {
        this.gameDone = gameDone;
    }

    isGameDone() {
        return this.gameDone;
    }

}