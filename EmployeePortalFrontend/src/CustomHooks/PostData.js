import { useState } from "react";

export default function usePostData() {
  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);
  const [isPending, setIsPending] = useState(false);

  const postData = async (router, data) => {
    setIsPending(true);

    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(data),
    };

    const response = await fetch(router, requestOptions);

    if (!response.ok) {
      setError(response.error);
    }

    if (response.ok) {
      response.api = "Added";
      setResponse(response);
    }

    setIsPending(false);
  };

  return { response, error, isPending, postData };
}
