import img1 from '../../assets/nextIcon.png';
import img2 from '../../assets/previousIcon.png';

const HeadingProduct = ({title, onNextClick, onPreviousClick}) => {
    return (
        <div className='w-full bg-[#F4F4F4] px-[48px] py-[25px] rounded-[184px] flex items-center justify-between mb-[40px] text-[#1F3E97]'>
            <p className='text-[24px]'>{title}</p>
            <div className='flex gap-2 items-center'>
                <button onClick={onPreviousClick}>
                    <img src={img2} alt="" />
                </button>
                <button onClick={onNextClick}>
                    <img src={img1} alt="" />
                </button>
            </div>
        </div>
    );
}

export default HeadingProduct;