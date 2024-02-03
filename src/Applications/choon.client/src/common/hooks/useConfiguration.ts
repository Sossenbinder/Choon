import { useContext } from 'react';
import { ConfigContext } from '../components/contexts/configContext';

export default function useConfiguration() {
    return useContext(ConfigContext);
}
