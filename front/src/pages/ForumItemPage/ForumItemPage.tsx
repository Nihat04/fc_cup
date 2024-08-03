import { useParams } from 'react-router-dom'

import { useEffect } from 'react'

import { getForum } from '../../api/forum'

import Header from '../../components/Header/Header'

const ForumItemPage = () => {
    const { id } = useParams()

    useEffect(() => {
        getForum(id).then(res => console.log(res))
    }, [])

  return (
    <>
        <Header />
        <main>
            <section>
                
            </section>
        </main>
    </>
  )
}

export default ForumItemPage