import Product from "../product/Product";
import img1 from "../../assets/popular-1.png";
import img2 from "../../assets/popular-2.png";
import img3 from "../../assets/popular-3.png";
import img4 from "../../assets/popular-4.png";
import img5 from "../../assets/popular-5.png";

const Popular = () => {
    const products = [
        {
            title: "Vantela Republic Low Black Natural",
            img: img1,
            cost: 120000,
            like: 4
        },
        {
            title: "Vantela New Public White low",
            img: img2,
            cost: 320000,
            like: 4.5
        },
        {
            title: "Vantela Public Low Black Natural",
            img: img3,
            cost: 20000,
            like: 4
        },
        {
            title: "Vantela Evil X Papa Gading Black Natural",
            img: img4,
            cost: 2000,
            like: 4
        },
        {
            title: "Vantela Evil",
            img: img5,
            cost: 52000,
            like: 3.5
        },
    ];

    return (
        <Product
            headingTitle="Most Popular"
            products={products}
        ></Product>
    );
}

export default Popular;