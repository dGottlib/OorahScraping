import React, {useState, useEffect} from 'react';
import axios from 'axios';

const Home = () => {
  const [prizes, setPrizes] = useState([]);

  useEffect(() => {
      const getPrizes = async () => {
          const {data} = await axios.get('/api/oorah/scrape');
          setPrizes(data);
      }

      getPrizes();   
  }, [])

  console.log(prizes)

  return (
    <div className = 'container mt-5'>
        <div className='row mt-3'>
           <div className='col-md-12'>
              <div className='row'>
                <h2>Winners of 2022 Oorah Raffle!</h2>
                <a href={"https://www.oorahauction.org/"}>Go to the Oorah Website</a>
              </div>
               {!!prizes.length && <table className='table table-hover table-striped table-bordered'>
                 <thead>
                    <tr>
                        <td>Image</td>
                        <td>Title</td>
                        <td>Winner</td>
                    </tr>
                 </thead>
                 <tbody>
                     {prizes.map((item, idx) => {
                         return <tr key={idx}>
                             <td><img alt={item.title} src={item.imageUrl} /></td>
                             <td>{item.title}</td>
                             <td>{item.winner}</td>
                         </tr>
                     })}
                 </tbody>
               </table>}
           </div>
        </div>
    </div>
  )
}

export default Home;