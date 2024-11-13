import logo from '../../assets/vantela.png';
import img1 from '../../assets/Group.png';
import img2 from '../../assets/like.png';
import img3 from '../../assets/bag.png';

const Header = () => {
    return (
        <div className='flex justify-between items-center px-12 h-[70px] w-full'>
            <h3 className='font-[Pacifico] text-[40px] italic text-[#1F3E97]'>vantela</h3>
            <div className='flex justify-between items-center w-[50%]'>
                <ul className='flex justify-center items-center gap-6'>
                    <li><a href="#" className='font-bold font-[inter] text-[14px] text-[#1F3E97]'>Home</a></li>
                    <li><a href="#" className='text-[#858585] font-[inter] text-[14px] '>Sneakers</a></li>
                    <li><a href="#" className='text-[#858585] font-[inter] text-[14px] '>Slip On</a></li>
                    <li><a href="#" className='text-[#858585] font-[inter] text-[14px] '>Sandals</a></li>
                    <li><a href="#" className='text-[#858585] font-[inter] text-[14px] '>Other</a></li>
                </ul>
                <div className='flex justify-center items-center gap-4'>
                    <img src={img1} alt="" />
                    <img src={img2} alt="" />
                    <img src={img3} alt="" />
                </div>
                <div className='flex gap-4'>
                    <a href="#" className='px-4 py-3 capitalize font-bold text-[#ffffff] text-[12px] bg-[#1F3E97] rounded-[71px]'>sign up</a>
                    <a href="#" className='px-4 py-3 capitalize font-bold bg-white text-[12px] text-[#1F3E97] rounded-[71px]'>sign in</a>
                </div>
            </div>
        </div>
    );
}

export default Header;