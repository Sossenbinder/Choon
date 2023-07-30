import { useContext } from "react";
import { Context, ServiceContext } from "../components/contexts/serviceContext";

export default function useServices(): ServiceContext {
	return useContext(Context);
}
