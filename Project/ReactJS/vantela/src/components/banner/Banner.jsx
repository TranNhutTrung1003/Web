import img1 from "../../assets/banner.png";

const Banner = () => {
    return (
        <div className="bg-[#FAFAFA] w-full h-[560px] relative mb-[40px]">
            <div className="w-full flex justify-center gap-6 items-center">
                <div className="w-[38%]">
                    <h1 className="text-[117px] font-[Pacifico] text-[#1F3E97] font-bold">vantela</h1>
                    <h3 className="text-[#FFB800] font-[inter] text-[39px]"><span className="font-bold">PUBLIC HIGH</span> GUM NATURAL</h3>
                    <p className="mb-3 font-[inter] text-[12px]">It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing</p>
                    <a href="#" className="inline-block text-white px-[32px] py-[16px] rounded-[40px] bg-[#1F3E97] font-semibold">Shop Now</a>
                </div>
                <div>
                    <img src={img1} alt="" />
                </div>
            </div>
            <div className="absolute flex justify-end gap-2 items-center right-[14.5rem] bottom-[50px] ">
                <button className="w-[16px] bg-[#D9D9D9] h-[16px] rounded-full"></button>
                <button className="w-[16px] bg-[#FFB800] h-[16px] rounded-full"></button>
                <button className="w-[16px] bg-[#D9D9D9] h-[16px] rounded-full"></button>
            </div>
        </div>
    );
}

export default Banner;