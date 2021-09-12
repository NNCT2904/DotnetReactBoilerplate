import React, { useState, useEffect } from "react";

// export interface dataSchemas {
//     productId: String,
//     name: String,
//     description: String,
//     price: Float32Array,
// }

const Product = ({ productId, name, description, price, maximumQuantity }) => {
  return (
    <div>
      <h2>{name}</h2>
      <p>AUD${price}</p>
      <p>{description}</p>
      {maximumQuantity !== null && <p>Maximum quantity: {maximumQuantity}</p>}
      <hr/>
    </div>
  );
};

const ProductPage = (props) => {
  const [data, setData] = useState([]);

  const fetchData = async () => {
    const res = await fetch("api/product/fetch");
    const products = await res.json();
    setData(products);
  };

  const getData = async () => {
    const res = await fetch("api/product");
    const products = await res.json();
    setData(products);
  }

  const clearData = async () => {
    const res = await fetch("api/product/clear", {
        method: 'DELETE'
    });
    const products = await res.json();
    setData(products);
  }

  useEffect(() => {
    getData();
  }, []);

  return (
    <div>
      <h1>Products</h1>
      <button onClick={() => setData(fetchData())}>Fetch data</button>
      <button onClick={() => setData(getData())}>Get data</button>
      <button onClick={() => setData(clearData())}>Clear Database</button>
      <hr/>
      {data &&
        data.length > 0 &&
        data.map((prod) => (
          <Product
            key={prod.productId}
            name={prod.name}
            price={prod.price}
            description={prod.description}
            maximumQuantity={prod.maximumQuantity}
          />
        ))}
    </div>
  );
};

export default ProductPage;
