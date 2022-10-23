import { Route, Redirect } from 'react-router-dom';
import { atom, useRecoilValue } from 'recoil';

const authAtom = atom({
	key: 'auth',
	default: JSON.parse(localStorage.getItem('user'))
});

export { PrivateRoute };

function PrivateRoute({ component: Component, ...rest}) {
	const auth = useRecoilValue(authAtom);

	return (
		<Route {...rest} render={props => {
			if(!auth) {
				return <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
			}

			return <Component {...props} />
		}} />
	);
}