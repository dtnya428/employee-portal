import { useState } from "react";

export default function useUpdateRecord() {
  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);
  const [isPending, setIsPending] = useState(false);

  const updateRecord = async (router, inputData) => {
    setIsPending(true);

    const requestOptions = {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(inputData),
    };

    const response = await fetch(router, requestOptions);
    
    if (!response.ok) {
      setError(response.error);
    }

    if (response.ok) {
      response.api = "Updated";
      setResponse(response);
    }

    setIsPending(false);
  };

  return { response, error, isPending, updateRecord };
}
