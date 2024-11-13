import img1 from "../../assets/search.png";

const Search = () => {
    return (
        <form method="" action="" className="w-full flex justify-center items-center h-[120px]">
            <div className="w-[40%] bg-[#F4F4F4] px-[40px] py-[16px] rounded-[48px] flex justify-between">
                <input type="text" name="" id="" placeholder="Search..." className="text-[#858585] outline-none w-[90%] bg-[#F4F4F4]"/>
                <button type="submit" className="">
                    <img src={img1} alt="" />
                </button>
            </div>
        </form>
    );
}

export default Search;