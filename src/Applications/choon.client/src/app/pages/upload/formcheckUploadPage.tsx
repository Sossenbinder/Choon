import UploadBox from '@formcheck/components/upload/uploadbox';
import classes from './formcheckUploadPage.module.scss';

export function FormCheckUploadPage() {
    return (
        <div className={classes.container}>
            <UploadBox />
        </div>
    );
}
