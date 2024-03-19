import { useState } from "react";

export default function useGetData() {
  const [responseData, setResponseData] = useState([]);
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const fetchData = async (url) => {
    if (url) {
      try {
        setIsLoading(true);
        const response = await fetch(url);
        const json = await response.json();

        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${json.error}`);
        } else {
          setResponseData(json);
          setError(null);
        }
      } catch (error) {
        setResponseData(null);
        setError(error);
      } finally {
        setIsLoading(false);
      }
    }
  };

  return { responseData, error, isLoading, fetchData };
}
