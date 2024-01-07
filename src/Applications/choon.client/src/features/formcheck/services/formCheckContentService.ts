import { CreateFormCheckRequest } from "@formcheck/types/network";
import { IFormCheckContentService } from "../types/services";

export default class FormCheckContentService
  implements IFormCheckContentService
{
  constructor() {}

  uploadFormCheckAsset = async (
    uploadFile: File,
    formCheckMetaInfo: CreateFormCheckRequest
  ) => {
    const formData = new FormData();
    formData.append("file", uploadFile!);
    formData.append("payload", JSON.stringify(formCheckMetaInfo));

    await fetch("https://localhost:2336/formcheck", {
      method: "POST",
      body: formData,
    });
  };
}
