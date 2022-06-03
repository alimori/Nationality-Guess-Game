import { OnInit, Component } from '@angular/core';
import { PersonService } from 'src/app/_services/pesron.service';
import { from, of, interval } from 'rxjs';
import { concatMap, delay, switchMap, takeWhile } from 'rxjs/operators';
import { StatusEnum } from 'src/app/_enumurations/status.enum';
import { NationalityEnum } from 'src/app/_enumurations/nationality.enum';
import { SharedService } from 'src/app/_services/shared.service';
import { Router } from '@angular/router';
import { PersonModel } from 'src/app/_models/person.model';


@Component({
    selector: 'app-game-page',
    templateUrl: 'game-page.component.html'
})
export class GamePageComponent implements OnInit {

    persons = [];
    score = 0;
    seconds = 3;
    interval$;

    constructor(private personService: PersonService,
        private sharedService: SharedService,
        private router: Router) {
        this.score = this.sharedService.getScore();
    }

    public get nationalityEnum(): typeof NationalityEnum {
        return NationalityEnum;
    }

    public get statusEnum(): typeof StatusEnum {
        return StatusEnum;
    }

    ngOnInit() {
        this.loadPersons();
        this.interval$ = setInterval(() => { this.seconds -= 1 }, 1000);
        setTimeout(() => {
            clearInterval(this.interval$);
        }, 3000);
    }


    loadPersons() {
        let totalPersons: PersonModel[] = [];
        this.personService.getPersons().subscribe(result => {
            totalPersons = result;


            from(totalPersons).pipe(
                concatMap(item => of(item).pipe(delay(3500)))
            ).subscribe(timedItem => {
                timedItem.status = this.statusEnum.INPROGRESS;
                this.persons.push(timedItem);
                console.log(timedItem);
                setTimeout(() => {
                    if (this.persons.filter(x => x == timedItem)[0]) {
                        this.persons = this.persons.filter(x => x != timedItem);
                        this.sharedService.DecreaseScore();
                        this.score = this.sharedService.getScore();
                    }
                }, 3000)
            }, err => {
            }, () => {
                setTimeout(() => {
                    this.finishGame();
                }, 3500);
            });

        });
    }

    selectNationality(nationality: NationalityEnum) {
        let person = this.persons.filter(x => x.status == this.statusEnum.INPROGRESS)[0];
        if (person.nationality == nationality) {
            person.status = this.statusEnum.SUCCESS;
            this.sharedService.increasScore();
            this.score = this.sharedService.getScore();
            this.persons = this.persons.filter(x => x != person);
        }
        else {
            person.status = this.statusEnum.FAILED;
            this.sharedService.DecreaseScore();
            this.score = this.sharedService.getScore();
            this.persons = this.persons.filter(x => x != person);
        }
    }

    finishGame() {
        this.sharedService.setGameDone(true);
        this.router.navigateByUrl('/home-page');
    }
}