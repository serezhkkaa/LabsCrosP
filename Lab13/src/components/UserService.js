import { useEffect, useState } from "react";
import { useOktaAuth } from "@okta/okta-react";

const useAuthUser = () => {
	const { oktaAuth, authState } = useOktaAuth();
  const [userInfo, setUserInformation] = useState(null);

	useEffect(() => {
		const fetchUser = async () => {
			try {
				const userResponse = await oktaAuth.getUser();
				setUserInformation(userResponse);
			} catch (error) {
				console.log(error);
			}
		};

		authState?.isAuthenticated && fetchUser();
	}, [authState, oktaAuth]);

	return userInfo;
};

export default useAuthUser;