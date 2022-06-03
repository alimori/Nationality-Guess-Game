import { NationalityEnum } from '../_enumurations/nationality.enum';
import { StatusEnum } from '../_enumurations/status.enum';

export class PersonModel {

    id: number;
    nationality: NationalityEnum;
    imagePath: string;
    status: StatusEnum;

    constructor() {
        this.status = StatusEnum.TODO;
    }
}

