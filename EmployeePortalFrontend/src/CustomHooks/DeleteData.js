import { useState } from "react";

export default function useDeleteRecord() {
  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);
  const [isPending, setIsPending] = useState(false);

  const deleteRecord = async (router) => {
    setIsPending(true);

    const requestOptions = {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
    };
    const response = await fetch(router, requestOptions);

    if (!response.ok) {
      setError(response.error);
    }

    if (response.ok) {
      response.api = "Deleted";
      setResponse(response);
    }

    setIsPending(false);
  };

    return { response, error, isPending, deleteRecord };
}
