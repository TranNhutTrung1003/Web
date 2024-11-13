import { useState } from "react";
import HeadingProduct from "../heading/HeadingProduct";
import ListProduct from "./ListProduct";
import ProductItem from "./ProductItem";

const Product = ({ headingTitle, products }) => {
    const [index, setIndex] = useState(0);

    function handleNextClick() {
        setIndex((prevIndex) => (prevIndex + 1) % products.length);
    }

    function handlePrevClick() {
        setIndex((prevIndex) => (prevIndex - 1 + products.length) % products.length);
    }

    const getProduct = (offset) => {
        return products[(index + offset) % products.length];
    };

    return (
        <div className="w-full px-[80px] mb-[40px]">
            <HeadingProduct
                title={headingTitle}
                onNextClick={handleNextClick}
                onPreviousClick={handlePrevClick}
            />
            <ListProduct>
                <ProductItem
                    img={getProduct(0).img}
                    title={getProduct(0).title}
                    cost={getProduct(0).cost}
                    like={getProduct(0).like}
                />
                <ProductItem
                    img={getProduct(1).img}
                    title={getProduct(1).title}
                    cost={getProduct(1).cost}
                    like={getProduct(1).like}
                />
                <ProductItem
                    img={getProduct(2).img}
                    title={getProduct(2).title}
                    cost={getProduct(2).cost}
                    like={getProduct(2).like}
                />
                <ProductItem
                    img={getProduct(3).img}
                    title={getProduct(3).title}
                    cost={getProduct(3).cost}
                    like={getProduct(3).like}
                />
            </ListProduct>
        </div>
    );
}

export default Product;
