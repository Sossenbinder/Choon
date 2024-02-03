import { Configuration } from '@common/contexts/configContext';
import { IAccountService } from '../types/services';

export default class AccountService implements IAccountService {
    private readonly apiUrl: string;

    constructor(configuration: Configuration) {
        this.apiUrl = configuration.apiUrl;
    }
}
