import FormCheckPage from "app/pages/root/formcheckPage";
import { FormCheckUploadPage } from "app/pages/upload/formcheckUploadPage";
import { Route, Routes } from "react-router-dom";

export function PageRouter() {
  return (
    <Routes>
      <Route path="/upload" element={<FormCheckUploadPage />} />
      <Route path="*" element={<FormCheckPage />} />
    </Routes>
  );
}
