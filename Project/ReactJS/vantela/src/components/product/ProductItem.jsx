import img1 from "../../assets/star.png";
import { useState } from "react";

const ProductItem = ({img, title, cost, like}) => {
    const [isClick, setIsClick] = useState(false);
    const handleClick = () => {
        setIsClick(!isClick);
    }

    return (
        <div className="w-[20%] border border-[#F4F4F4] box-border px-4 py-3 rounded-lg h-[390px]" onClick={handleClick}>
            <div className="w-full">
                <img src={img} alt="" className="w-full h-[242px] mb-4"/>
            </div>
            <div className="w-full">
                <p className="w-full h-[54px] overflow-hidden font-[Inter] mb-2 font-semibold text-[18px]">{title}</p>
                <p className="font-[Inter] text-[12px] mb-4">{cost} VND</p>
                <div className={isClick === true ? "flex justify-between items-center" : "hidden"}>
                    <p className="flex items-center gap-2 overflow-hidden">
                        <img src={img1} alt="" />
                        {like}/5
                    </p>
                    <a href="#" className="bg-[#1F3E97] text-white rounded-full px-[12px] py-[6px]">Shop Now</a>
                </div>
            </div>
        </div>
    );
}

export default ProductItem;