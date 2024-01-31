import { Configuration } from '@common/contexts/configContext';
import { CreateFormCheckRequest } from '@formcheck/types/network';
import { IFormCheckContentService } from '../types/services';

export default class FormCheckContentService implements IFormCheckContentService {
    private readonly apiUrl: string;

    constructor(configuration: Configuration) {
        this.apiUrl = configuration.apiUrl;
    }

    uploadFormCheckAsset = async (uploadFile: File, formCheckMetaInfo: CreateFormCheckRequest) => {
        const formData = new FormData();
        formData.append('file', uploadFile!);
        formData.append('payload', JSON.stringify(formCheckMetaInfo));

        await fetch(`${this.apiUrl}/formcheck`, {
            method: 'POST',
            body: formData,
        });
    };
}
