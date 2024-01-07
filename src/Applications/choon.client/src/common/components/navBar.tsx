import classes from './navBar.module.scss';
import { Flex, Group } from '@mantine/core';
import ThemeToggleButton from './controls/themeToggleButton';
import UploadButton from '@formcheck/components/upload/uploadButton';
import { Link } from '@tanstack/react-router';

export default function NavBar() {
    return (
        <Flex className={classes.header} justify="space-between" align="center" direction="row">
            <Link to="/">Choon</Link>
            <Group>
                <ThemeToggleButton />
                <UploadButton />
            </Group>
        </Flex>
    );
}
