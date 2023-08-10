import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Statistics } from "./components/Statistics";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        element: <FetchData />
    }
    ,
    {
        path: '/statistics',
        element: <Statistics/>
    }
];

export default AppRoutes;
