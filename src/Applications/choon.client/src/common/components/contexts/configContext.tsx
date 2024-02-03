import React from 'react';

export type Configuration = {
    apiUrl: string;
};

export const ConfigContext = React.createContext<Configuration>({} as Configuration);

export default function ConfigurationContextProvider({ context, children }: React.PropsWithChildren<{ context: Configuration }>) {
    return <ConfigContext.Provider value={context}>{children}</ConfigContext.Provider>;
}
