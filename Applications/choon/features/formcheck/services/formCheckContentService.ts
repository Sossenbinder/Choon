import { IFormCheckContentService } from "../types";

export default class FormCheckContentService implements IFormCheckContentService {
	constructor() {}

	uploadFormCheckAsset = async (uploadFile: File) => {
		const formData = new FormData();
		formData.append("file", uploadFile!);

		await fetch("https://localhost:2336/formcheck", {
			method: "POST",
			body: formData,
		});
	};
}
